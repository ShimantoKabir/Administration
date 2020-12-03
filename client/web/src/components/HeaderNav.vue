<template>
    <div class="header-nav">
        <i v-on:click="onBarBtnClick" class="fas fa-bars" ></i>
    </div>
</template>

<script>
export default {
    name: "HeaderNav",
    props: {
        onBarBtnClick: {
            type: Function,
            default() {
                return function () {
                };
            }
        }
    },
    methods : {

    }
}
</script>

<style scoped>
.header-nav{
    display: flex;
    padding: 5px;
    width: 100%;
    height: 50px;
    flex-direction: row;
    align-items: center;
    background-color: red;
}
</style>