"use client";
import { useEffect, useState } from "react";
import api from "../lib/api";
import PropertyCard from "../components/PropertyCard";

export default function Home() {
  const [properties, setProperties] = useState<any[]>([]);
  const [search, setSearch] = useState("");
  const [minPrice, setMinPrice] = useState<number | "">("");
  const [maxPrice, setMaxPrice] = useState<number | "">("");

  useEffect(() => {
    api
      .get("/property")
      .then((res) => {
        setProperties(Array.isArray(res.data.items) ? res.data.items : []);
      })
      .catch(() => {});
  }, []);
  useEffect(() => {
    // console.log(properties);
    // console.log(first)
  });
  const filtered = properties.filter((p) => {
    const s = search.toLowerCase();
    const matchSearch =
      p.name?.toLowerCase().includes(s) ||
      p.addressProperty?.toLowerCase().includes(s);
    const matchMin = minPrice === "" || p.priceProperty >= Number(minPrice);
    const matchMax = maxPrice === "" || p.priceProperty <= Number(maxPrice);
    return matchSearch && matchMin && matchMax;
  });

  return (
    <div className="space-y-4">
      <h1 className="text-3xl font-bold">Propiedades</h1>
      <div className="flex gap-3">
        <input
          type="text"
          placeholder="Buscar por título o dirección"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="border p-2 w-full rounded"
        />
        <input
          type="number"
          placeholder="Min"
          className="border p-2 w-28 rounded"
          value={minPrice}
          onChange={(e) =>
            setMinPrice(e.target.value ? Number(e.target.value) : "")
          }
        />
        <input
          type="number"
          placeholder="Max"
          className="border p-2 w-28 rounded"
          value={maxPrice}
          onChange={(e) =>
            setMaxPrice(e.target.value ? Number(e.target.value) : "")
          }
        />
      </div>
      <div className="grid md:grid-cols-3 gap-4">
        {filtered.map((p) => (
          <PropertyCard key={p._id} property={p} />
        ))}
      </div>
    </div>
  );
}
