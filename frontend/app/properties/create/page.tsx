"use client";
import { useState } from "react";
import { useRouter } from "next/navigation";
import api from "../../../lib/api";

export default function CreateProperty() {
  const [id, setId] = useState("");
  const [idOwner, setIdOwner] = useState("");
  const [name, setName] = useState("");
  const [addressProperty, setAddressProperty] = useState("");
  const [priceProperty, setPriceProperty] = useState<number | "">("");
  const [imageUrl, setImageUrl] = useState("");
  const router = useRouter();

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    try {
      await api.post("/property", {
        id,
        idOwner,
        name,
        addressProperty,
        priceProperty: priceProperty === "" ? 0 : priceProperty,
        imageUrl,
      });
      router.push("/");
    } catch (err) {
      alert("Failed to create property");
    }
  }

  return (
    <div className="max-w-md mx-auto bg-white p-6 rounded-xl shadow">
      <h1 className="text-2xl font-bold mb-4">Crear Propiedad</h1>
      <form onSubmit={submit} className="flex flex-col gap-3">
        <input
          placeholder="ID"
          className="border p-2 rounded"
          value={id}
          onChange={(e) => setId(e.target.value)}
        />
        <input
          placeholder="ID Owner"
          className="border p-2 rounded"
          value={idOwner}
          onChange={(e) => setIdOwner(e.target.value)}
        />
        <input
          placeholder="Nombre"
          className="border p-2 rounded"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <input
          placeholder="Dirección"
          className="border p-2 rounded"
          value={addressProperty}
          onChange={(e) => setAddressProperty(e.target.value)}
        />
        <input
          type="number"
          placeholder="Precio"
          className="border p-2 rounded"
          value={priceProperty}
          onChange={(e) =>
            setPriceProperty(e.target.value ? Number(e.target.value) : "")
          }
        />
        <input
          placeholder="Image URL"
          className="border p-2 rounded"
          value={imageUrl}
          onChange={(e) => setImageUrl(e.target.value)}
        />
        <button className="bg-blue-600 text-white px-4 py-2 rounded">
          Crear
        </button>
      </form>
    </div>
  );
}
