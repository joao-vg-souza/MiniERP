<template>
    <div>
        <default-modal @submitEvent="submitEvent" :title="'Inserir Categoria'">
            <v-text-field label="Nome" v-model="model.nome">
            </v-text-field>
            <v-text-field label="Descrição" v-model="model.descricao">
            </v-text-field>
        </default-modal>
    </div>
</template>

<script>
export default { 
    data() {
        return {
            model: {}
        }
    },
    methods: {
        async submitEvent() {
            const response = await this.$controllers.categoria.create(JSON.stringify(this.model));
        }
    }
}
</script>