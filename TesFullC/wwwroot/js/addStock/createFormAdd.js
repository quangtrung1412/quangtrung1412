import callApi1 from "../callApi1.js";
function insertStock(stock) {
    callApi1("StockApi/Insert", "POST", JSON.stringify(stock)).catch(err => console.log(err))
}
//function getStock() {
//    callApi1("StockApi").then(resp => {
//        res.forEach()
//    });
//}
//getStock();
document.getElementById("editForm").addEventListener("submit", evt => {
    evt.preventDefault();
    const { target } = evt;
    const formdata = new FormData(target);
    let objToPost = {};
    formdata.forEach((value, key) => {
        
        if (key != "id") {
            objToPost[key] = Number(value)
        } else {
            objToPost[key] = value;
        }
        
    });
    console.log(objToPost)
    insertStock(objToPost);
});
