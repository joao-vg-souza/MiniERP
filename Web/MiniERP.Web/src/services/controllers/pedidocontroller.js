const controller = "/Pedido";

import baseApi from "../base/api.js";

export default Object.assign({
  create: async function (dto) {
    return await baseApi.post(`${controller}`, dto);
  },
  update: async function (dto) {
    return await baseApi.put(`${controller}`, dto);
  },
  remove: async function (dto) {
    return await baseApi.delete(`${controller}`, dto);
  },
  getAll: async function () {
    return await baseApi.get(`${controller}`);
  },
  getById: async function (id) {
    return await baseApi.get(`${controller}/${id}`);
  },
});
