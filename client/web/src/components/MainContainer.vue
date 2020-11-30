<template>
  <div class="main-container" >
    <side-nav></side-nav>
    <div class="sub-container" >
      <header-nav></header-nav>
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import SideNav from "@/components/SideNav";
import HeaderNav from "@/components/HeaderNav";
export default {
  name: "MainContainer",
  components: {HeaderNav, SideNav}
}
</script>

<style scoped>
  .main-container{
    display: flex;
    width: 100vw;
    height: 100vh;
    flex-direction: row;
  }
  .sub-container{
    flex: 8;
  }
</style>