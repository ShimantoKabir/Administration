import { createApp } from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store'

import '@/assets/css/main.css'
import '@/assets/css/grid.css'
import '@/assets/css/font.css'

window.axios = require('axios');

createApp(App).use(store).use(router).mount('#app')
