export interface Session {

  sessionId: string;

  eventId: string;

  speakerId?: string;

  sessionTitle: string;

  description?: string;

  sessionStart: string;

  sessionEnd: string;

  sessionUrl?: string;

  speaker?: {

    speakerId: string;

    speakerName: string;

  };

}