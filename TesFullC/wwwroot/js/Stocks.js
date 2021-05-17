import  callApi1 from "./callApi1.js";
import CreateTableStock from "./createTableStocks.js";


var stockTableObj = new CreateTableStock("#root");

async function getStock() {
    callApi1("StockApi/GetAllStock").then(resp => {
        
        stockTableObj.setData(resp)
    }).catch(err => console.log(err))
}
await getStock()

