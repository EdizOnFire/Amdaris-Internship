import { Routes, Route, BrowserRouter } from "react-router-dom";
import { ItemProvider } from "./contexts/ItemContext";
import { Header, Footer } from "./components";
import { Home, Upload, NotFound, YourAudioFiles } from "./pages";
import { QueryClient, QueryClientProvider } from 'react-query';
import { Theme } from './services/theme'

const queryClient = new QueryClient()

function App() {
  return (
    <BrowserRouter>
     <Theme>
      <QueryClientProvider client={queryClient}>
        <Header />
        <ItemProvider>
          <main>
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/your-audio-files" element={<YourAudioFiles />} />
              <Route path="/upload" element={<Upload />} />
              <Route path="*" element={<NotFound />} />
            </Routes>
          </main>
        </ItemProvider>
        <Footer />
      </QueryClientProvider>
      </Theme>
    </BrowserRouter>
  );
}

export default App;
