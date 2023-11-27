const SelectType = document.querySelector("#SelectType");
const SelectTypeDiv = document.querySelector("#SelectTypeDiv");
var isSelectTypeDiv = false;
const SelectTypeSpans = SelectTypeDiv.querySelectorAll("span");

const ListItems = document.querySelectorAll(".ListItems");

SelectType.addEventListener("click", () => {

    if (isSelectTypeDiv) {
        SelectTypeDiv.style.display = "none";
    } else {
        SelectTypeDiv.style.display = "block";
    }
    isSelectTypeDiv = !isSelectTypeDiv;


    SelectTypeSpans.forEach((e, i) => {
        e.addEventListener("click", () => {
            ShowOnly(i, e);
        });
    });
});

document.addEventListener("click", (event) => {
    if (event.target !== SelectType) {
        SelectTypeDiv.style.display = "none";
        isSelectTypeDiv = false;
    }
});

const ShowOnly = (index, element) => {
    ListItems.forEach((e, i) => {
        let item = e.querySelector(".TestTypeDisplay");
       
        if (element.innerHTML == "All") {
            e.style.display = "table-row";
        } else {
            if (item.innerHTML == element.innerHTML) {
                e.style.display = "table-row";
            } else {
                e.style.display = "none";
            }
        }
    });
}