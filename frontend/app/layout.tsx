import "./globals.css";
import Navbar from "../components/Navbar";

export const metadata = {
  title: "Real Estate App",
  description: "Frontend con Next.js + Tailwind + Axios",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="es">
      <body className="bg-gray-100 min-h-screen">
        <Navbar />
        <main className="p-6">{children}</main>
      </body>
    </html>
  );
}
