const units = ["bpm", "%", "kg", "cm", "cm", ""];

//Create & Edit

try {
    const TestType = document.querySelector("#TestType");
    const TestTypeInput = TestType.querySelector("#TestTypeInput");
    const BodyMeasure = document.querySelector("#BodyMeasure");
    const ValueUnit = document.querySelector("#ValueUnit");
    const ValueDiv = document.querySelector("#ValueDiv");



    TestTypeInput.addEventListener('click', () => {
        showCorrectInputs();
    });

    const showCorrectInputs = () => {

        BodyMeasure.style.display = "none";

        if (TestTypeInput.value == "4") {
            BodyMeasure.style.display = "block";
        }


        ValueUnit.innerHTML = units[parseInt(TestTypeInput.value)];

        if (units[parseInt(TestTypeInput.value)] != "" && units[parseInt(TestTypeInput.value)] != undefined) {
            ValueDiv.classList.remove('col-12');
            ValueDiv.classList.add('col-10');

            ValueUnit.classList.add('col-2');
        } else {
            ValueDiv.classList.remove('col-10');
            ValueDiv.classList.add('col-12');

            ValueUnit.classList.remove('col-2');
        }
    }

    showCorrectInputs();
} catch { }

//Index, Details & Delete

try {
    const ValueDisplay = document.querySelectorAll(".ValueDisplay");
    const TestTypeDisplay = document.querySelectorAll(".TestTypeDisplay");
    const BodyMeasure = document.querySelectorAll(".BodyMeasure");
    const BodyMeasureList = document.querySelectorAll(".BodyMeasureList");

    async function fetchEnumValues() {
        const response = await fetch('/Tests/GetEnumValues');
        const enumValues = await response.json();

        let index = [];

        ValueDisplay.forEach((e, i) => {

            index[i] = enumValues.indexOf(TestTypeDisplay[i].innerHTML);

            ValueDisplay[i].innerHTML += ` ${units[index[i]]}`;

            try {
                if (index[i] == "4") {
                    BodyMeasureList[i].style.display = "block";
                } else {
                    BodyMeasureList[i].innerHTML = "-";
                }
            } catch { }
        });

        BodyMeasure.forEach(e => {
            if (index == "4") {
                e.style.display = "block";
            } else {
                e.style.display = "none";
            }
        });
    }

    document.addEventListener('DOMContentLoaded', () => {
        fetchEnumValues();
    });
} catch { }