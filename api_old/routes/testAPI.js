var express = require('express');
var router = express.Router();
const { MongoClient } = require('mongodb');


async function main() {
  const uri = 'mongodb+srv://chaley3399:Dalton99!@cluster0.xxmnv.mongodb.net/myFirstDatabase?retryWrites=true&w=majority';
  const client = new MongoClient(uri, { useNewUrlParser: true, useUnifiedTopology: true });

  try {
    await client.connect();
    await listDatabases(client);
  } catch (err) {
    console.error(err);
  } finally {
    await client.close();
  }
  
}

async function listDatabases(client) {
  databaseList = await client.db().admin().listDatabases();

  console.log("Databases:");
  databaseList.databases.forEach(db => console.log(` - ${db.name}`));
};

router.get('/', function (req, res, next) {
  res.send('API is working!');
});

main().catch(console.error);

module.exports = router;