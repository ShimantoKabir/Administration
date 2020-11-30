<template>
    <div class="my-template">
        <transition name="slide-fade">
            <div class="alert-modal" v-if="isOpen"  >
                <div class="alert-area" >
                    <c-card>
                        <c-card-header>
                            <i class="fas fa-bell" ></i><strong> {{prop.title}}</strong>
                        </c-card-header>
                        <c-card-body class="alert-body" >
                            <i v-if="prop.bodyIcon" :class=prop.bodyIcon ></i>
                            {{prop.bodyMsg}}
                        </c-card-body>
                        <c-card-footer>
                            <c-row class="justify-content-between alert-footer" >
                                <c-button v-if="prop.try" color="primary" size="sm" v-on:click="tryAgain" >
                                    <i class="fas fa-redo" ></i>
                                </c-button>
                                <c-button v-if="prop.try" color="danger" size="sm" v-on:click="close" >
                                    <i class="fas fa-times-circle" ></i>
                                </c-button>
                                <c-button v-if="prop.ok" color="success" size="sm" v-on:click="close" >
                                    <i class="fas fa-check-circle" ></i>
                                </c-button>
                                <c-button v-if="prop.confirm" color="warning" size="sm" v-on:click="yes" >
                                    <i class="fas fa-check-circle" ></i>
                                </c-button>
                                <c-button v-if="prop.confirm" color="success" size="sm" v-on:click="no" >
                                    <i class="fas fa-times-circle" ></i>
                                </c-button>
                            </c-row>
                        </c-card-footer>
                    </c-card>
                </div>
            </div>
        </transition>
    </div>
</template>

<script>
export default {
    name: "Alert",
    props: {
        onAlertClose: {
            type: Function,
            default() {
                return function () {
                };
            }
        }
    },
    mounted() {
        this.prop.needFooter = true;
    },
    data() {
        return {
            isOpen: false,
            isConfirm: false,
            prop: {
                title: '',
                bodyMsg: '',
                bodyIcon: '',
                width: '100%',
                onCallBack: {},
                onNoClick: {},
                ok: false,
                try: false,
                confirm: false,
                code: 200
            }
        }
    },
    methods: {
        close() {
            this.onAlertClose();
            this.isOpen = false;
        },
        open() {
            this.isOpen = true;
        },
        tryAgain() {
            this.prop.onCallBack();
        },
        show(prop) {

            this.isOpen = true;

            this.prop.title = prop.title;
            this.prop.bodyIcon = prop.bodyIcon;
            this.prop.bodyMsg = prop.bodyMsg;
            this.prop.width = prop.width;

            this.prop.onCallBack = prop.onCallBack;
            this.prop.onNoClick = prop.onNoClick;

            this.prop.try = prop.try;
            this.prop.ok = prop.ok;
            this.prop.confirm = prop.confirm;

            this.prop.code = prop.code;
            this.isConfirm = !this.isConfirm;
            return this.isConfirm;

        },
        yes() {
            this.prop.onCallBack();
            this.close();
        },
        no() {

            if (this.prop.onNoClick) {

                this.prop.onNoClick();
                this.onAlertClose();
                this.isOpen = false;

            }

            this.close();
        }

    }
}
</script>

<style scoped>
.alert-modal {
    position: fixed;
    z-index: 1200;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    overflow: auto;
    background-color: rgba(0, 0, 0, 0.4);
}

.alert-area {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
}

.alert-footer{
    padding-left: 10px;
    padding-right: 10px;
}
.alert-body{
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
}
.alert-body > i {
    font-size: 30px;
    margin-right: 10px;
}
</style>