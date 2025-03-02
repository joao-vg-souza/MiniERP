<template>
    <v-dialog max-width="500">
        <template v-slot:activator="{ props: activatorProps }">
            <v-btn v-bind="activatorProps" color="green" icon="mdi mdi-plus">
            </v-btn>
        </template>

        <template v-slot:default="{ isActive }">
            <v-card :title="title">
                <v-card-text>
                    <slot></slot>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>

                    <v-btn color="red" variant="tonal" text="Cancelar" @click="isActive.value = false"></v-btn>
                    <v-btn color="green" variant="tonal" text="Salvar" @click="emitSubmit"></v-btn>
                </v-card-actions>
            </v-card>
        </template>
    </v-dialog>
</template>

<script>
export default {
    data() {
        return {

        }
    },
    methods: {
        emitSubmit() {
            this.$emit('submitEvent');
        }
    },
    props: {
        title: String
    },
    emits: ['submitEvent']
}
</script>