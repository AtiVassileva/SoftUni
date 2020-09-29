let daysOfWeek = ['Monday', 'Tuesday', 'Wednesday', "Thursday", 'Friday', 'Saturday', 'Sunday'];

function PrintPositionOfDay(day) {

    let index = daysOfWeek.indexOf(day);

    if (index == -1) {
        console.log('error');
        return;
    }

    console.log(index + 1);
}
