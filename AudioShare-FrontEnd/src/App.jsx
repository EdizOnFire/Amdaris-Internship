import { RouterProvider, createBrowserRouter } from "react-router-dom";
import { ItemProvider } from "./contexts/ItemContext";
import { Home, Upload, Browse, NotFound } from "./pages";
import { Theme } from "./services/theme";
import Layout from "./components/Layout/Layout";

export default function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout />,
      children: [
        {
          index: true,
          element: <Home />,
        },
        {
          path: "browse",
          element: <Browse />,
        },
        {
          path: "upload",
          element: <Upload />,
        },
        {
          path: "*",
          element: <NotFound />,
        },
      ],
    },
  ]);

  return (
    <Theme>
      {/* <ItemProvider> */}
      <RouterProvider router={router} />
      {/* </ItemProvider> */}
    </Theme>
  );
}
