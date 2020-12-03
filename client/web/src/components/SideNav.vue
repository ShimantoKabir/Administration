<template>
    <div class="side-nav">
        <div class="logo-area" >
            <img src="../assets/img/logo.png" alt="logo">
            <h4>Administration</h4>
        </div>
        <div v-if="selectedMenuObj.menuName !== 'Root'" class="menu-back-area" v-on:click="onBackClick(selectedMenuObj)"  >
            <h5>{{selectedMenuObj.menuName}}</h5>
            <i class="fas fa-chevron-left" ></i>
        </div>
        <div class="menu-area" >
            <ul>
                <li v-for="(c,i) in selectedMenuObj.children" v-on:click="onMenuClick(c,i)" >
                    <a href="#" >{{c.menuName}}</a>
                    <i v-if="c.children" class="fas fa-chevron-right" ></i>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
    name: "SideNav",
    mounted() {
        this.selectedMenuObj = this.menu;
    },
    data(){
        return{
            selectedMenuObj : {
                menuName : "Root",
                children : [
                    {
                        menuName: "User"
                    },
                    {
                        menuName: "Menu",
                        children: [
                            {
                                menuName: "Manage",
                                children: [
                                    {
                                        menuName: "Manage x"
                                    },
                                    {
                                        menuName: "Permission x"
                                    }
                                ]
                            },
                            {
                                menuName: "Permission"
                            }
                        ]
                    }
                ]
            },
            menu : {
                menuName : "Root",
                children : [
                    {
                        menuName: "User"
                    },
                    {
                        menuName: "Menu",
                        children: [
                            {
                                menuName: "Manage",
                                children: [
                                    {
                                        menuName: "Manage x"
                                    },
                                    {
                                        menuName: "Permission x"
                                    }
                                ]
                            },
                            {
                                menuName: "Permission"
                            }
                        ]
                    }
                ]
            },
            x : ''
        }
    },
    methods : {
        onMenuClick(obj,i){
            this.selectedMenuObj = JSON.parse(JSON.stringify(obj));
        },
        onBackClick(){
            
            this.findParent(this.menu);
            this.selectedMenuObj = JSON.parse(JSON.stringify(this.x));

        },
        findParent(obj){
            for (let i = 0; i < obj.children.length; i++) {

                if (obj.children[i].menuName === this.selectedMenuObj.menuName){
                    this.x = obj;
                }else {
                    if (obj.children[i].children){
                        this.findParent(obj.children[i]);
                    }
                }
            }
        }
    }
}
</script>

<style scoped>
.side-nav {
    flex: 2;
    background-color: slategrey;
    color: white;
}
.logo-area {
    display: flex;
    padding: 10px;
    width: 100%;
    height: 50px;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}

.logo-area > img {
    width: 30px;
    height: 30px;
}

.logo-area > h4 {
    margin-left: 10px;
}
.menu-area{
    border-top: 1px solid lightgray;
}

.menu-area > ul {

}

.menu-area > ul > li{
    padding: 10px 20px;
    border-bottom: 1px solid lightgray;
    display: flex;
    justify-content: space-between;
    cursor: pointer;
}

.menu-area > ul > li > a {
    color: black;
    text-decoration: none;
}
.menu-back-area{
    display: flex;
    justify-content: space-between;
    padding: 10px 20px;
    cursor: pointer;
}
</style>