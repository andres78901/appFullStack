"use client";
import { useEffect, useState } from "react";
import { useParams, useRouter } from "next/navigation";
import api from "../../../lib/api";

export default function PropertyDetail() {
  const { id } = useParams();
  const [property, setProperty] = useState<any | null>(null);
  const router = useRouter();

  useEffect(() => {
    if (id)
      api
        .get(`/property/${id}`)
        .then((res) => setProperty(res.data))
        .catch(() => {});
  }, [id]);

  async function handleDelete() {
    if (!confirm("¿Eliminar propiedad?")) return;
    try {
      await api.delete(`/property/${id}`);
      router.push("/");
    } catch {
      alert("Failed to delete");
    }
  }

  if (!property) return <p>Loading...</p>;

  return (
    <div className="max-w-3xl mx-auto bg-white p-6 rounded-xl shadow">
      {property.imageUrl && (
        <img
          src={property.imageUrl}
          alt={property.title}
          className="w-full h-64 object-cover rounded-md mb-4"
        />
      )}
      <h1 className="text-3xl font-bold">{property.name}</h1>
      <p className="text-gray-600">{property.addressProperty}</p>
      <p className="text-green-600 font-bold text-xl">${property.priceProperty}</p>
      <div className="flex gap-3 mt-4">
        <button
          onClick={() => router.push(`/properties/edit/${property.id}`)}
          className="bg-yellow-500 px-3 py-1 rounded"
        >
          Editar
        </button>
        <button
          onClick={handleDelete}
          className="bg-red-500 px-3 py-1 rounded text-white"
        >
          Eliminar
        </button>
      </div>
    </div>
  );
}
