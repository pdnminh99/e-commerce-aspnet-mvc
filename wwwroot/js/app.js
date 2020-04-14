// const shoppingCart = (function () {
//     let cartString = localStorage.getItem("cart");
//     if (cartString == null) {
//         localStorage.setItem("cart", "{}");
//         return {}
//     }
//     return JSON.parse(cartString)
// })();
//
// const addProductToCart = ({productId, title, image, originalPrice, category, brand}, count) => {
//     if (count == null) {
//         count = 1;
//     }
//     let existingItem = shoppingCart[productId];
//     if (existingItem == null) {
//         shoppingCart[productId] = {productId, title, image, originalPrice, category, brand, count}
//     } else {
//         shoppingCart.count += count;
//     }
//     if (shoppingCart[productId].title !== title) {
//         shoppingCart[productId].title = title;
//     }
//     if (shoppingCart[productId].image !== image) {
//         shoppingCart[productId].image = image;
//     }
//     if (shoppingCart[productId].originalPrice !== originalPrice) {
//         shoppingCart[productId].originalPrice = originalPrice;
//     }
//     if (shoppingCart[productId].category !== category) {
//         shoppingCart[productId].category = category;
//     }
//     if (shoppingCart[productId].brand !== brand) {
//         shoppingCart[productId].brand = brand;
//     }
//     localStorage.setItem("cart", JSON.parse(shoppingCart))
// };
//
// const itemCountDisplayElement = document.getElementById("cart-item-count");
// const totalPriceDisplayElement = document.getElementById("cart-total-price");
//
// const refreshShoppingCart = () => {
//     let totalPrice = 0;
//     let totalItemsCount = 0;
//
//     for (let itemId in Object.values(shoppingCart)) {
//         totalPrice += shoppingCart[itemId].count * shoppingCart[itemId].originalPrice;
//         totalItemsCount += shoppingCart[itemId].count;
//     }
//     itemCountDisplayElement.innerText = totalItemsCount + (totalItemsCount > 1 ? ' items' : 'item');
//     totalPriceDisplayElement.innerText = `${totalPrice}$`
// };
//
// function addItem(json) {
//     addProductToCart(JSON.parse(json), 1);
//     refreshShoppingCart();
// }
//
// refreshShoppingCart();