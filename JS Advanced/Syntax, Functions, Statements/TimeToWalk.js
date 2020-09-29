function CalculateWalkingTime(totalSteps, footprintLength, speed) {
    let distanceInMeters = totalSteps * footprintLength;
    let speedInMeterPerSec = speed / 3.6;

    let breaks = Math.floor(distanceInMeters / 500);

    let timeInSeconds = distanceInMeters / speedInMeterPerSec + breaks * 60;

    let hours = Math.floor(timeInSeconds / 3600);
    let minutes = Math.floor(timeInSeconds / 60);
    let seconds = Math.ceil(timeInSeconds % 60);

     
    console.log(`${hours < 10? 0 : ''}${hours}:${minutes < 10 ? 0 : ''}${minutes}:${seconds < 10 ? 0 : ''}${seconds}`);

    }
    