import Thead from "./pthead.js";
import * as CONFIGS from "./TableStockConfigs.js";

class TableStock {
    /**
     * 
     * @param {string} cssSelector // id, className, ... của phan tư html đe append table vào (vd: #id, .classname...)
     */
    constructor(cssSelector) {
        this.table = this.createTable();
        document.querySelector(cssSelector).appendChild(this.table);
    }
    createTable() {
        const table = document.createElement("table");        
        table.innerHTML = Thead;
        table.appendChild(this.createTbody());
        return table;
    }
    createTbody() {
        const tbody = document.createElement("tbody");
        
        return tbody;
    }


    /**
     * 
     * 
     * @param {Object} data
     */
    addRow(data) {
        const tr = document.createElement("tr");
        CONFIGS.ALL_ATTR.forEach(attr => {
            const td = document.createElement("td");
            if (CONFIGS.NOT_CHANGE_COLOR.includes(attr)) {
                if (attr == "giaTc") {
                    td.classList.add("reColor")
                }
                if (attr == "giaTran") {
                    td.classList.add("ceColor")
                }
                if (attr == "giaSan") {
                    td.classList.add("flColor")
                }
                if (attr == "tongKl" || attr == "nnmua" || attr == "nnban" || attr == "roomConLai") {
                    td.classList.add("noColor")
                }

            }
            CONFIGS.SAME_COLOR.forEach(vals => {
                if (vals.includes(attr)) {
                    if (data["giaTran"] == data[vals[0]]) {
                        td.classList.add("ceColor");
                    }
                    if (data["giaSan"] == data[vals[0]]) {
                        td.classList.add("flColor");
                    }
                    if (data["giaTran"] != data[vals[0]] && data["giaSan"] != data[vals[0]]) {
                        if (data["giaTc"] > data[vals[0]]) {
                            td.classList.add("redColor");
                        } else if (data["giaTc"] < data[vals[0]]) {
                            td.classList.add("greenColor");
                        } else {
                            td.classList.add("reColor");
                        }
                    }
                     
                    
                    
                }
                })
            if (data[attr] === 0) {
                data[attr] = "";
            }
            td.innerText = data[attr]
            tr.appendChild(td);
        })
        return tr;

    }

    /**
     * 
     * Set du lieu cho bang
     * @param {Array<Object>} data
     */
    setData(data) {
        data.forEach(dt => {
           
            var tr = this.addRow(dt);
            this.table.tBodies[0].appendChild(tr);
        })
    }
}
export default TableStock;