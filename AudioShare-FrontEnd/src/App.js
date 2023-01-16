import { RouterProvider, createBrowserRouter } from "react-router-dom";
import { ItemProvider } from "./contexts/ItemContext";
import { Home, Upload, Browse, Login, Register, NotFound } from "./pages";
import { Theme } from "./services/theme";
import AudioFiles, { audioFilesLoader } from "./components/AudioFiles/AudioFiles";
import Layout from "./components/Layout/Layout";
import { submitLogin } from "./pages/Login/Login";
import { submitRegister } from "./pages/Register/Register";

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
          children: [
            {
              index: true,
              element: <AudioFiles />,
              loader: audioFilesLoader,
            },
          ],
        },
        {
          path: "upload",
          element: <Upload />,
        },
        {
          path: "login",
          element: <Login />,
          action: submitLogin
        },
        {
          path: "register",
          element: <Register />,
          action: submitRegister
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
      <ItemProvider>
        <RouterProvider router={router} />
      </ItemProvider>
    </Theme>
  );
}
