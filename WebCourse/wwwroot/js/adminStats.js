$(document).ready(() => {
    getStats();
});

function getStats(){
    axios.get('/api/stats/')
    .then(function (response) {
        let stats = response.data.stats;
        fillMain(stats);
        fillBadges(stats);
    })
    .catch(function (error) {
        console.log(error);
    });
}
function fillBadges(data){
  $("#badgeUsers").text(data.usersCount);
  $("#badgeNews").text(data.newsCount);
  $("#badgeProducts").text(data.productsCount);
  $("#badgeCompanies").text(data.companiesCount);
  $("#badgeZapr").text(123);
}

function fillMain(data){
  let output = `
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-user" aria-hidden="true"></span> ${data.usersCount}</h2>
                    <h4>Пользователи</h4>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> ${data.newsCount}</h2>
                    <h4>Новости</h4>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-scale" aria-hidden="true"></span> ${data.productsCount}</h2>
                    <h4>Продукты</h4>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="well dash-box">
                    <h2><span class="glyphicon glyphicon-briefcase" aria-hidden="true"></span> ${data.companiesCount}</h2>
                    <h4>Предприятия</h4>
                  </div>
                </div>
                
        `;
      $('#stats').html(output);
}