//-----------------------------------------------------------------------
// <copyright file="MessageType.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MessageType enumeration.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    /// <summary>
    /// Represents the MessageType enumeration.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// The message type alive message.
        /// </summary>
        AliveMessage,

        /// <summary>
        /// The message type move request.
        /// </summary>
        MoveRequest,

        /// <summary>
        /// The message type move response.
        /// </summary>
        MoveResponse,

        /// <summary>
        /// The message type opponents move.
        /// </summary>
        OpponentsMove,

        /// <summary>
        /// The message type move report.
        /// </summary>
        MoveReport,

        /// <summary>
        /// The message type ship positions.
        /// </summary>
        ShipPositions,

        /// <summary>
        /// The message type lobby response.
        /// </summary>
        LobbyResponse,

        /// <summary>
        /// The message type lobby request.
        /// </summary>
        LobbyRequest,

        /// <summary>
        /// The message type new battle request.
        /// </summary>
        NewBattleRequest,

        /// <summary>
        /// The message type join battle request.
        /// </summary>
        JoinBattleRequest,

        /// <summary>
        /// The message type confirm battle.
        /// </summary>
        ConfirmBattle,

        /// <summary>
        /// The message type decline battle.
        /// </summary>
        DeclineBattle,

        /// <summary>
        /// The message type initiate battle.
        /// </summary>
        InitiateBattle,

        /// <summary>
        /// The message type game won.
        /// </summary>
        GameWon,

        /// <summary>
        /// The message type game lost.
        /// </summary>
        GameLost
    }
}