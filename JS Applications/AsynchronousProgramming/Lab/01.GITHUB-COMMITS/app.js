function loadCommits() {
    let username = document.getElementById('username').value;
    let repoName = document.getElementById('repo').value;
    let commitsUl = document.getElementById('commits');

    const url = `https://api.github.com/repos/${username}/${repoName}/commits`;

    fetch(url)
        .then(response => response.json())
        .then(result => {
            result.map(data => commitsUl.innerHTML += `<li>${data.commit.author.name} ${data.commit.message}</li>`);
        })
        .catch(error => {
            commitsUl.innerHTML = `<li>Error: ${error.status} (${error.statusText})</li>`;
        });

    username.value = '';
    repoName.value = '';
    commitsUl.innerHTML = '';
}