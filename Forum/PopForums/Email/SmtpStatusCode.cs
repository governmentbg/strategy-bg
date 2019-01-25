﻿namespace PopForums.Email
{
    public enum SmtpStatusCode
	{
		SystemStatus = 211,
		HelpMessage = 214,
		ServiceReady = 220,
		ServiceClosingTransmissionChannel = 221,
		AuthenticationSuccessful = 235,
		Ok = 250,
		UserNotLocalWillForward = 251,
		CannotVerifyUserWillAttemptDelivery = 252,
		AuthenticationChallenge = 334,
		StartMailInput = 354,
		ServiceNotAvailable = 421,
		PasswordTransitionNeeded = 432,
		MailboxBusy = 450,
		ErrorInProcessing = 451,
		InsufficientStorage = 452,
		TemporaryAuthenticationFailure = 454,
		CommandUnrecognized = 500,
		SyntaxError = 501,
		CommandNotImplemented = 502,
		BadCommandSequence = 503,
		CommandParameterNotImplemented = 504,
		AuthenticationRequired = 530,
		AuthenticationMechanismTooWeak = 534,
		AuthenticationInvalidCredentials = 535,
		EncryptionRequiredForAuthenticationMechanism = 538,
		MailboxUnavailable = 550,
		UserNotLocalTryAlternatePath = 551,
		ExceededStorageAllocation = 552,
		MailboxNameNotAllowed = 553,
		TransactionFailed = 554,
		MailFromOrRcptToParametersNotRecognizedOrNotImplemented = 555
	}
}
