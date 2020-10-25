function attachEventsListeners() {
    
    let inputDistance = document.getElementById('inputDistance');
    let inputUnits = document.getElementById('inputUnits');
    let output = document.getElementById('outputDistance');
    let outputUnits = document.getElementById('outputUnits');
    let button = document.getElementById('convert');
    
    let unitsObj = {
        km:1000,
        m:1,
        cm:0.01,
        mm:0.001,
        mi:1609.34,
        yrd:0.9144,
        ft:0.3048,
        in:0.0254,
    }

    button.addEventListener('click', () => {
 
        let convertFrom = inputUnits.value;
        let convertTo = outputUnits.value;
        
        let valueInMeters = inputDistance.value * unitsObj[convertFrom];
        let convertedValue = valueInMeters / unitsObj[convertTo];
        output.value = convertedValue;
    })
}