function createArticle() {
	let titleInput = document.getElementById("createTitle");
	let contentInput = document.getElementById("createContent");

	if (titleInput.value != '' && contentInput.value != '') {

		let headingElement = document.createElement('h3');
		headingElement.textContent = titleInput.value;
		titleInput.value = '';

		let paragraphElement = document.createElement('p');
		paragraphElement.textContent = contentInput.value;
		contentInput.value = '';

		let currentArticle = document.createElement('article');
		currentArticle.appendChild(headingElement);
		currentArticle.appendChild(paragraphElement);

		let articlesElements = document.getElementById('articles');
		articlesElements.appendChild(currentArticle);
	}
}