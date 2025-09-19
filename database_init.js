db = db.getSiblingDB('realestate_db');
db.users.insertOne({ Email: "test@example.com", PasswordHash: "", Name: "Test User" });
db.properties.insertMany([
  { IdOwner: "owner1", Name: "Casa Bonita", AddressProperty: "Calle 1", PriceProperty: 250000, ImageUrl: "https://via.placeholder.com/400" },
  { IdOwner: "owner2", Name: "Apartamento Lago", AddressProperty: "Calle 2", PriceProperty: 180000, ImageUrl: "https://via.placeholder.com/400" }
]);