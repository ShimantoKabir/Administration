<template>
    <div class="main-container">
        <side-nav v-show="isSideNavOpen" ></side-nav>
        <div class="sub-container">
            <header-nav :on-bar-btn-click="onBarBtnClick" ></header-nav>
            <router-view></router-view>
        </div>
    </div>
</template>

<script>
import SideNav from "@/components/SideNav";
import HeaderNav from "@/components/HeaderNav";

export default {
    name: "MainContainer",
    components: {HeaderNav, SideNav},
    mounted() {
    },
    data(){
        return{
            isSideNavOpen : true
        }
    },
    methods : {
        onBarBtnClick(){
            this.isSideNavOpen = !this.isSideNavOpen;
        }
    }
}
</script>

<style scoped>
.main-container {
    display: flex;
    width: 100vw;
    height: 100vh;
    flex-direction: row;
}

.sub-container {
    flex: 8;
    display: flex;
    flex-direction: row;
    width: 100%;
    height: 100%;
}
</style>