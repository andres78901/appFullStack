"use client";
import { useEffect, useState } from "react";
import { useParams, useRouter } from "next/navigation";
import api from "../../../../lib/api";

export default function EditProperty() {
  const { id } = useParams();
  const [idOwner, setIdOwner] = useState("");
  const [name, setName] = useState("");
  const [addressProperty, setAddressProperty] = useState("");
  const [priceProperty, setPriceProperty] = useState<number | "">("");
  const [imageUrl, setImageUrl] = useState("");
  const router = useRouter();

  useEffect(() => {
    if (id)
      api
        .get(`/property/${id}`)
        .then((res) => {
          const p = res.data;
          setIdOwner(p.idOwner || "");
          setName(p.name || "");
          setAddressProperty(p.addressProperty || "");
          setPriceProperty(p.priceProperty || "");
          setImageUrl(p.imageUrl || "");
        })
        .catch(() => {});
  }, [id]);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    try {
      await api.put(`/property/${id}`, {
        idOwner,
        name,
        addressProperty,
        priceProperty: priceProperty === "" ? 0 : priceProperty,
        imageUrl,
      });
      router.push(`/properties/${id}`);
    } catch (err) {
      alert("Failed to update");
    }
  }

  return (
    <div className="max-w-md mx-auto bg-white p-6 rounded-xl shadow">
      <h1 className="text-2xl font-bold mb-4">Editar Propiedad</h1>
      <form onSubmit={submit} className="flex flex-col gap-3">
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
          Guardar
        </button>
      </form>
    </div>
  );
}
