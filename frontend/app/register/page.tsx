"use client";
import { useState } from "react";
import { useRouter } from "next/navigation";
import api from "../../lib/api";

export default function Register() {
  const [email, setEmail] = useState("");
  const [name, setNombre] = useState("");
  const [password, setPassword] = useState("");
  const router = useRouter();

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    try {
      await api
        .post("/auth/register", { email, password, name })
        .then((res) => {
          alert("Registro exitoso, ahora inicia sesión");
          router.push("/login");
        })
        .catch((err) => {
          if (err.status === 409) {
            alert("Usuario ya ha sido registrado");
          }
        });
    } catch {
      alert("Error en el registro");
    }
  }

  return (
    <div className="max-w-md mx-auto bg-white p-6 rounded-xl shadow">
      <h1 className="text-2xl font-bold mb-4">Registro</h1>
      <form onSubmit={handleSubmit} className="flex flex-col gap-3">
        <input
          type="etext"
          placeholder="Nombre"
          value={name}
          onChange={(e) => setNombre(e.target.value)}
          className="border p-2 rounded"
        />
        <input
          type="email"
          placeholder="Correo"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="border p-2 rounded"
        />
        <input
          type="password"
          placeholder="Contraseña"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          className="border p-2 rounded"
        />
        <button className="bg-green-600 text-white px-4 py-2 rounded">
          Registrarse
        </button>
      </form>
    </div>
  );
}
