db = db.getSiblingDB("realestate_db");
db.users.insertOne({
  Email: "test@example.com",
  PasswordHash: "",
  Name: "Test User",
});
db.properties.insertMany([
  {
    IdOwner: "owner1",
    Name: "Casa Bonita",
    AddressProperty: "Calle 1",
    PriceProperty: 250000,
    ImageUrl:
      "https://scontent.fbog4-2.fna.fbcdn.net/v/t39.30808-6/548884239_823624733657462_1833087810263918356_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeGD4Kcnw-rUoOQuRpJQLXQKPpYXY-Ht5dM-lhdj4e3l02BjokYL4w9qkucOg3umAQEWcyKR8YSSm9bLhKkcNVO0&_nc_ohc=YSFb-JZyZ4oQ7kNvwGYOGzo&_nc_oc=AdnmQicY4BcyKojgJNQUHRqE6PkIwJxctJJedc2JfC2-5wUSXweZDeGobeIX-bkSBpw&_nc_zt=23&_nc_ht=scontent.fbog4-2.fna&_nc_gid=mC_KerycCb7JM4JEu0EJcw&oh=00_Afa2AG-Kh2vtW9VNkLM4ljX0hGpnZJ4k-7P4zgDyXm4okg&oe=68D27A5D",
  },
  {
    IdOwner: "owner2",
    Name: "Apartamento Lago",
    AddressProperty: "Calle 2",
    PriceProperty: 180000,
    ImageUrl:
      "https://scontent.fbog4-1.fna.fbcdn.net/v/t39.30808-6/549853190_823705066982762_5302421378887623302_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=833d8c&_nc_eui2=AeEO2IRm-EwIxKXKYy9bA217xzPT7GmqpODHM9Psaaqk4K5erx5Lb0P7qYYk8KLkmnCZunrkSm81xLcMy8Q9dQc9&_nc_ohc=I2NMnj7626cQ7kNvwGerxHp&_nc_oc=Adk4EHFrNSkknmootsu1qJv9JKj25NrEUtoruTPTclJ6T-UbN9BbXP5N_giyluU2JoM&_nc_zt=23&_nc_ht=scontent.fbog4-1.fna&_nc_gid=aKKqTDhB--yzs3EJ_ZbCNw&oh=00_AfaWl3Enf2xC1RZw4NPJdRo29QRBC_QFy-fzfN0hqfY-4A&oe=68D272E9",
  },
]);
