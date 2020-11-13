function loadRepos() {
	let usernameInput = document.getElementById('username');
	let reposList = document.getElementById('repos');

	const url = `https://api.github.com/users/${usernameInput.value}/repos`;

	fetch(url).then(response => response.json())
		.then(repos => {
			repos.forEach(repo => {
				let currentLi = document.createElement('li');
				let repoLink = document.createElement('a');
				repoLink.href = repo.html_url;
				repoLink.textContent = repo.name;
				currentLi.appendChild(repoLink);
				reposList.appendChild(currentLi);
			});
		});

		reposList.innerHTML = '';
		usernameInput.value = '';
}