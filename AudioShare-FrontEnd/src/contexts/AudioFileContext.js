import { createContext, useReducer, useEffect } from "react";
// import { ADD_COMMENT, ADD_ITEM, ADD_ITEMS, EDIT_ITEM, FETCH_ITEM_DETAILS, DELETE_ITEM } from "../constants";
import { ADD_ITEM, ADD_ITEMS, EDIT_ITEM, FETCH_ITEM_DETAILS, DELETE_ITEM } from "../constants";

import * as itemService from "../services/itemService";

export const AudioFileContext = createContext();

const itemReducer = (state, action) => {
    switch (action.type) {
        case ADD_ITEMS:
            return action?.payload.map((x) => ({ ...x }));
        //   return action.payload.map((x) => ({ ...x, comments: [] }));
        case ADD_ITEM:
            return [...state, action.payload];
        case FETCH_ITEM_DETAILS:
        case EDIT_ITEM:
            return state.map((x) => (x.id === action.itemId ? action.payload : x));
        // case ADD_COMMENT:
        //   return state.map(
        //     (x) =>
        //       x._id === action.itemId && {
        //         ...x,
        //         comments: [...x.comments, action.payload]
        //       }
        //   );
        case DELETE_ITEM:
            return state.filter((x) => x.id !== action.itemId);
        default:
            return state;
    }
};

export const AudioFileProvider = ({ children }) => {
    const [items, send] = useReducer(itemReducer, []);

    useEffect(() => {
        itemService.getAll().then((result) => {
            const action = {
                type: "ADD_ITEMS",
                payload: result,
            };

            send(action);
        });
    }, []);

    const selectItem = (itemId) => {
        return items.find((x) => x.id == itemId)
    };

    const downloadUrl = async (path) => {
        const response = await itemService.download(path)
        const url = URL.createObjectURL(response);
        return url;
    }

    const fetchItemDetails = (itemId, itemDetails) => {
        send({
            type: "FETCH_ITEM_DETAILS",
            payload: itemDetails,
            itemId,
        });
    };

    //   const addComment = (itemId, comment) => {
    //     send({
    //       type: "ADD_COMMENT",
    //       payload: comment,
    //       itemId,
    //     });
    //   };

    const itemAdd = (itemData) => {
        send({
            type: "ADD_ITEM",
            payload: itemData,
        });
    };

    const itemEdit = (itemId, itemData) => {
        send({
            type: "EDIT_ITEM",
            payload: itemData,
            itemId,
        });
    };

    const itemRemove = (itemId) => {
        send({
            type: "DELETE_ITEM",
            itemId,
        });
    };

    return (
        <AudioFileContext.Provider
            value={{
                items,
                itemAdd,
                // addComment,
                fetchItemDetails,
                selectItem,
                downloadUrl,
                itemEdit,
                itemRemove,
            }}>
            {children}
        </AudioFileContext.Provider>
    );
};