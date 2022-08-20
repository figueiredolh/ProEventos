import { Lote } from './Lote';
import { RedeSocial } from './RedeSocial';
import { Palestrante } from "./Palestrante";

export interface Evento {
  id: Number;
  imagemUrl?: string;
  tema: string;
  local: string;
  data: Date;
  qtdPessoas: number;
  lotes: Lote[];
  redesSociais: RedeSocial[];
  eventosPalestrantes: Palestrante[];
}
