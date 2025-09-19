import Link from "next/link";

export default function Navbar() {
  const token = typeof window !== "undefined" ? localStorage.getItem("token") : null;
  return (
    <nav className="bg-white shadow p-4 flex justify-between items-center">
      <Link href="/" className="font-bold text-xl text-blue-600">Real Estate</Link>
      <div className="flex gap-4 items-center">
        <Link href="/properties/create" className="text-sm text-gray-700">Crear</Link>
        <Link href="/login" className="text-gray-700">Login</Link>
        <Link href="/register" className="text-gray-700">Registro</Link>
      </div>
    </nav>
  );
}
