export default {
    install(app) {
      import('../services/controllers/index').then((controllers) => {
        app.config.globalProperties.$controllers = controllers;
      });
    },
  };
  