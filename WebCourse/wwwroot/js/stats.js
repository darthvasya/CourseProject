$(document).ready(() => {
    getStats();
});

function getStats(){
    axios.get('/api/stats/')
    .then(function (response) {
        let stats = response.data;
        fillStats(stats.stats);
        fillLastProducts(stats.lastProducts);
        fillLastCompanies(stats.lastCompanies);
    })
    .catch(function (error) {
        console.log(error);
    });
}

function fillStats(stats){
    let output = `
        <li class="list-group-item">Зарегистрировано предприятий: ${stats.companiesCount}</li>
        <li class="list-group-item">Зарегистрировано продуктов: ${stats.productsCount}</li>
        <li class="list-group-item">Опубликовано новостей: ${stats.newsCount}</li>
    `;
    $('#stats').html(output);
}

function fillLastProducts(products){
    let output = '';
    $.each(products, (index, product) =>{
        output += `
            <li class="list-group-item"><a href="#">${product.productName}</a></li>
        `;
    });

    $('#products').html(output);
}

function fillLastCompanies(companies){
    let output = '';
    $.each(companies, (index, company) =>{
        output += `
            <li class="list-group-item"><a href="#">${company.name}</a></li>
        `;
    });

    $('#companies').html(output);
}
