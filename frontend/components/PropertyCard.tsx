import Link from "next/link";

export default function PropertyCard({ property }: { property: any }) {
  console.log(property);
  return (
    <div className="bg-white shadow rounded-xl p-4">
      <div className="h-40 w-full overflow-hidden rounded-md mb-3">
        {property.imageUrl ? (
          <img
            src={property.imageUrl}
            alt={property.name}
            className="w-full h-full object-cover"
          />
        ) : (
          <div className="w-full h-full bg-gray-200 flex items-center justify-center">
            No image
          </div>
        )}
      </div>
      <h2 className="text-xl font-semibold">{property.name}</h2>
      <p className="text-gray-600">{property.addressProperty}</p>
      <p className="text-blue-600 font-bold">${property.priceProperty}</p>
      <Link
        href={`/properties/${property.id}`}
        className="text-sm text-white bg-blue-600 px-3 py-1 rounded inline-block mt-2"
      >
        Ver detalle
      </Link>
    </div>
  );
}
