function Solve([speed, area]) {

    const residentialMax = 20;
    const interstateMax = 90;
    const motorwayMax = 130;
    const cityMax = 50;
    let output = '';

    switch (area) {
        case 'residential':
            output = CheckForSpeeding(speed, residentialMax);
            break;
        case 'city':
            output = CheckForSpeeding(speed, cityMax);
            break;
        case 'interstate':
            output = CheckForSpeeding(speed, interstateMax);
            break;
        case 'motorway':
            output = CheckForSpeeding(speed, motorwayMax);
            break;
    }

    console.log(output);
}


function CheckForSpeeding(speed, maxSpeed) {

    let result = '';
    if (speed <= maxSpeed) {
        result = ''
    } else if (speed - maxSpeed <= 20) {
        result = 'speeding';
    } else if (speed - maxSpeed <= 40) {
        result = 'excessive speeding';
    } else {
        result = 'reckless driving';
    }
    return result;
}
