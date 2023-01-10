import { createContext, useReducer, useEffect } from "react";
import { ADD_ITEM, ADD_ITEMS } from "../constants";

import * as itemService from "../services/itemService";

export const ItemContext = createContext();

const itemReducer = (state, action) => {
  switch (action.type) {
    case ADD_ITEMS:
      return action.payload.map((x) => ({ ...x, comments: [] }));
    case ADD_ITEM:
      return [...state, action.payload];
    default:
      return state;
  }
};

export const ItemProvider = ({ children }) => {
  const [items, send] = useReducer(itemReducer, []);

  useEffect(() => {
    itemService.getAll().then((result) => {
      const action = {
        type: "ADD_ITEMS",
        payload: result.data,
      };

      send(action);
    });
  }, []);

  const itemAdd = (itemData) => {
    send({
      type: "ADD_ITEM",
      payload: itemData,
    });
  };

  return (
    <ItemContext.Provider
      value={{
        items,
        itemAdd
      }}>
      {children}
    </ItemContext.Provider>
  );
};