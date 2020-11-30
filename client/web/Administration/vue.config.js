module.exports = {
  lintOnSave: false,
  runtimeCompiler: true,
  configureWebpack: {
    resolve: {
      symlinks: false
    }
  },
  transpileDependencies: [
    '@coreui/utils'
  ],
  devServer: {
    proxy: {
      '/api': {
        target: 'http://localhost:5000',
        changeOrigin: true
      },
    },
    host: 'localhost',
    port: 5002,
  }

}
