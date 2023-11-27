const Types = ["Pulse", "Saturation", "Weight", "Height", "Neck", "Arm", "Forearm", "Chest", "Waist", "Hips", "Thighs", "Calf"];
const Colors = ["c45d49", "e69f6a", "ebd754", "7aa628", "39e374", "39e3e0", "397de3", "5e39e3", "d239e3", "e33955"];

for (let i = 0; i < Types.length; i++) {
    eval(`
        var ${Types[i]} = []; 
        var ${Types[i]}Date = [];
    `);
}


dataArray.forEach((e, i) => {
    let switchCase = "switch (e.TestType) {";
    for (let i = 0; i < 4; i++) {
        switchCase += `
            case ${i}:
                ${Types[i]}.push(e.Value);
                ${Types[i]}Date.push(e.Date.substring(0, 10));
                break;
        `;
    }

    switchCase += `
        case 4:
            switch (e.BodyMeasure) {
    `;

    for (let i = 4; i < Types.length; i++) {
        switchCase += `
            case ${i-4}:
                ${Types[i]}.push(e.Value);
                ${Types[i]}Date.push(e.Date.substring(0, 10));
                break;
        `;
    }
    switchCase += `
            }
            break;
        }`;

    eval(switchCase);

});

for (let i = 0; i < Types.length; i++) {
    console.log(eval(Types[i]).length == 0);
    eval(`
        if(${eval(eval(Types[i]).length > 0)}){

            var ${Types[i]}Data = {
                labels: ${Types[i]}Date,
                datasets: [
                    {
                        label: "${Types[i]}",
                        data: ${Types[i]},
                        borderColor: '#${Colors[Math.floor(Math.random()*Colors.length)]}',
                        borderWidth: 2,
                        fill: false
                    }
                ]
            };

            var ${Types[i]}Options = {
                scales: {
                    y: {
                        suggestedMin: Math.min.apply(null, ${Types[i]}Data.datasets[0].data) - 10,
                        suggestedMax: Math.max.apply(null, ${Types[i]}Data.datasets[0].data) + 10
                    }
                }
            };

            const ${Types[i]}Ctx = document.querySelector("#${Types[i]}Chart").getContext('2d');

            var ${Types[i]}Chart = new Chart(${Types[i]}Ctx, {
                type: 'line',
                data: ${Types[i]}Data,
                options: ${Types[i]}Options
            });
        }else{
            const ${Types[i]}CtxParent = document.querySelector("#${Types[i]}Chart").parentNode;

            ${Types[i]}CtxParent.style.display = "none";
        }
    `);
}