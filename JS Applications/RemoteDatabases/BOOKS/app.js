const baseUrl = `https://books-b95f4.firebaseio.com/`;

const htmlSelectors = {
    'loadBtn': () => document.getElementById('loadBooks'),
    'tableBody': () => document.querySelector('table > tbody'),
    'addBtn': () => document.getElementById('submit'),
    'authorInput': () => document.getElementById('author'),
    'titleInput': () => document.getElementById('title'),
    'isbnInput': () => document.getElementById('isbn'),
    'editForm': () => document.getElementById('edit-form'),
    'editBtn': () => document.getElementById('editBtn'),
    'editedAuthor': () => document.getElementById('edit-author'),
    'editedTitle': () => document.getElementById('edit-title'),
    'editedIsbn': () => document.getElementById('edit-isbn'),
}

htmlSelectors['addBtn']().addEventListener('click', addBook);

htmlSelectors['loadBtn']().addEventListener('click', loadAllBooks);

// PRESS THE LOAD ALL BOOKS BUTTON WHEN ADDING AND EDITING A BOOK :)

function addBook(e) {
    e.preventDefault();
    if (!htmlSelectors['authorInput']().value || !htmlSelectors['titleInput']().value || !htmlSelectors['isbnInput']().value) {
        return;
    }

    let obj = JSON.stringify({
        author: htmlSelectors['authorInput']().value,
        title: htmlSelectors['titleInput']().value,
        isbn: htmlSelectors['isbnInput']().value,
    });

    fetch(baseUrl + `Books/.json`, {
        method: 'POST',
        body: obj
    });

    htmlSelectors['authorInput']().value = '';
    htmlSelectors['titleInput']().value = '';
    htmlSelectors['isbnInput']().value = '';
}

function loadAllBooks() {

    htmlSelectors['tableBody']().innerHTML = '';
    fetch(baseUrl + `Books/.json`).then(response => response.json())
        .then(data => {
            Object.keys(data).map(id => {
                let { author, title, isbn } = data[id];

                let deleteBookBtn = document.createElement('button');
                deleteBookBtn.textContent = 'Delete';
                let editBookBtn = document.createElement('button');
                editBookBtn.textContent = 'Edit';

                createDomElement(title, author, isbn, deleteBookBtn, editBookBtn);

                deleteBookBtn.addEventListener('click', deleteBook);

                editBookBtn.addEventListener('click', () => {
                    htmlSelectors['editForm']().style.display = 'block';

                    htmlSelectors['editBtn']().addEventListener('click', editBook);
                });

                function deleteBook(e) {
                    fetch(baseUrl + `Books/${id}/.json`, {
                        method: 'DELETE'
                    });
                    htmlSelectors['tableBody']().removeChild(e.currentTarget.parentElement);
                }

                function editBook(e) {
                    e.preventDefault();
                    if (!htmlSelectors['editedAuthor']().value || !htmlSelectors['editedTitle']().value || !htmlSelectors['editedIsbn']().value) {
                        return;
                    }

                    let obj = JSON.stringify({
                        author: htmlSelectors['editedAuthor']().value,
                        title: htmlSelectors['editedTitle']().value,
                        isbn: htmlSelectors['editedIsbn']().value,
                    });

                    fetch(baseUrl + `Books/${id}.json`, {
                        method: 'PUT',
                        body: obj,
                    });

                    htmlSelectors['editedAuthor']().value = '';
                    htmlSelectors['editedTitle']().value = '';
                    htmlSelectors['editedIsbn']().value = '';
                    htmlSelectors['editForm']().style.display = 'none';
                }
            });
        });
}

function createDomElement(title, author, isbn, ...children) {
    let row = document.createElement('tr');
    let titleDesc = document.createElement('td');
    titleDesc.textContent = title;

    let authorDesc = document.createElement('td');
    authorDesc.textContent = author;

    let isbnDesc = document.createElement('td');
    isbnDesc.textContent = isbn;

    row.appendChild(titleDesc);
    row.appendChild(authorDesc);
    row.appendChild(isbnDesc);

    children.forEach(child => row.appendChild(child));

    htmlSelectors['tableBody']().appendChild(row);
}