export class Incidente {

    constructor(
        public id: string,
        public descricao: string,
        public idusuario: string,
        public dataocorrido: Date,
        public status: string,
        public userid: string,
        public naoConformidadeId: string
      ) {  }
}
