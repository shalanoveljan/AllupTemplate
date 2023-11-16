$(document).ready(function () {
    $('#searchBtn').click(function (e) {
        e.preventDefault();

        let searchInput = $('#searchInput').val();
        let categoryId = $('#searchCategory').val();

        fetch('/shop/search?categoryId=' + categoryId + '&search=' + searchInput)
            .then(res => res.text())
            .then(data => {

                $('#searchData').html(data)
                console.log(data)
                
                    //old partial
                //let items = ''
                //for (var i = 0; i < data.length; i++) {

                //    let item = `  <li>
                //                            <a class="d-flex justify-content-between align-items-center ">
                //                                <img width="100px" src="assets//images/product/${data[i].mainImage}"/>
                //                                <p>${data[i].title}</p> 
                //                                <span class="regular-price">$${data[i].price}</span>
                //                            </a>
                //                        </li>`;

                //    items += item;
                //}

               



                })


    })


    $('.modalBtn').click(function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        fetch(url)
            .then(res => res.text())
            .then(data => {
                $('.modal-body').html(data);

                $('.quick-view-image').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    dots: false,
                    fade: true,
                    asNavFor: '.quick-view-thumb',
                    speed: 400,
                });

                $('.quick-view-thumb').slick({
                    slidesToShow: 4,
                    slidesToScroll: 1,
                    asNavFor: '.quick-view-image',
                    dots: false,
                    arrows: false,
                    focusOnSelect: true,
                    speed: 400,
                });
            })
    });
})

