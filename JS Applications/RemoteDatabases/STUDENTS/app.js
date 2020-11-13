const url = `https://students-70d62.firebaseio.com/.json`;

let inputData = Array.from(document.querySelectorAll('.inputData'));
let id = inputData[0];
let firstName = inputData[1];
let lastName = inputData[2];
let facultyNum = inputData[3];
let grade = inputData[4];

let addBtn = document.getElementById('addNew');

addBtn.addEventListener('click', () => {

    if (inputData.some(x => !x.value)) {
        return;
    }

    let student = JSON.stringify({
        id: id.value,
        firstName: firstName.value,
        lastName: lastName.value,
        facultyNumber: facultyNum.value,
        grade: grade.value
    });

    fetch(url, {
        method: 'POST',
        body: student,
    });

    inputData.forEach(x => x.value = '');
});

let showBtn = document.getElementById('show');
let tableBody = document.querySelector('#results tbody');
let hideBtn = document.getElementById('hide');

showBtn.addEventListener('click', () => {
    tableBody.style.display = 'block';

    fetch(url).then(response => response.json())
        .then(data => {
            Object.values(data)
                .sort((a, b) => a.id - b.id).forEach(stud => {
                    // &nbsp -> this is a space tag in case you see it for the first time :)
                    tableBody.innerHTML +=
                        `<tr>
                        <th>${stud.id} &nbsp</th>
                        <th>${stud.firstName} &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</th>
                        <th>${stud.lastName} &nbsp&nbsp</th>
                        <th>${stud.facultyNumber} &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</th>
                        <th>${Number(stud.grade).toFixed(2)}</th>
                    </tr>`;
                });
        });

    showBtn.style.display = 'none';
    hideBtn.style.display = 'block';

    hideBtn.addEventListener('click', () => {
        tableBody.innerHTML = '';
        hideBtn.style.display = 'none';
        showBtn.style.display = 'block';
    });
});