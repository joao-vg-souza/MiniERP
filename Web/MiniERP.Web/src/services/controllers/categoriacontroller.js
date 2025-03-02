const controller = "/Categoria";

import baseApi from "../base/api.js";

export default Object.assign({
  create: async function (dto) {
    return await baseApi.post(`${controller}`, dto);
  },
});
