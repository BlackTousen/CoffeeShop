const url = "https://localhost:5001/api/beanvariety/";
const url2 = "https://localhost:5001/api/coffee/";

const button = document.querySelector("#run-button");
const addButton = document.querySelector("#addButton");
button.addEventListener("click", () => {
    getAllBeanVarieties()
        .then(beanVarieties => {
            console.log(beanVarieties);
        })
            getAllCoffees()
        .then(coffees => {
            console.log(coffees);
        })
});
addButton.addEventListener("click", () => {
    const name = document.querySelector("name").value
    const region = document.querySelector("region").value
    const notes  = document.querySelector("#notes").value
    postData(url2,{name = name, region = region, notes = notes})
        .then(data => {
            console.log(data);
        })
});


function getAllBeanVarieties() {
    return fetch(url).then(resp => resp.json());
}
function getAllCoffees() {
    return fetch(url2).then(resp => resp.json());
}
async function postData(url = '', data = {}) {
  // Default options are marked with *
  const response = await fetch(url, {
    method: 'POST', // *GET, POST, PUT, DELETE, etc.
    mode: 'cors', // no-cors, *cors, same-origin
    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
    credentials: 'same-origin', // include, *same-origin, omit
    headers: {
      'Content-Type': 'application/json'
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: 'follow', // manual, *follow, error
    referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
    body: JSON.stringify(data) // body data type must match "Content-Type" header
  });
  return response.json(); // parses JSON response into native JavaScript objects
}