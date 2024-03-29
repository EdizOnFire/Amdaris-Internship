import { Home, Upload, Browse, NotFound, Details, Edit,Profile } from "./pages";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import { AudioFileProvider } from "./contexts/AudioFileContext";
import { AuthProvider } from "./contexts/AuthContext";
import { Theme } from "./Theme";
import Layout from "./components/Layout/Layout";

export default function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout />,
      errorElement: <NotFound />,
      children: [
        {
          index: true,
          element: <Home />,
          errorElement: <NotFound />,
        },
        {
          path: "browse",
          element: <Browse />,
          errorElement: <NotFound />,
        },
        {
          path: "upload",
          element: <Upload />,
          errorElement: <NotFound />,
        },
        {
          path: "browse/:id",
          element: <Details />,
          errorElement: <NotFound />,
        },
        {
          path: "browse/:id/edit",
          element: <Edit />,
          errorElement: <NotFound />,
        },
        {
          path: "profile",
          element: <Profile />,
          errorElement: <NotFound />,
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
      <AuthProvider>
        <AudioFileProvider>
          <RouterProvider router={router} />
        </AudioFileProvider>
      </AuthProvider>
    </Theme>
  );
}
