import { Guid } from 'guid-typescript';

export interface ClientAccount {
  id: Guid;
  name: string;
  balance: number;
}
