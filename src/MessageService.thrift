namespace * org.mustbe.consulo.ant.core.message

service MessageService
{
	void buildStarted(1:i32 priority);

	void buildFinished(1:i32 priority, 2:string exceptionText);

	void targetStarted(1:i32 priority, 2:string name);

	void targetFinished(1:i32 priority, 2:string exceptionText);

	void taskStarted(1:i32 priority, 2:string name);

	void taskFinished(1:i32 priority, 2:string exceptionText);

	void logInfo(1:i32 priority, 2:string message);

	void logError(1:i32 priority, 2:string message);

	void logException(1:i32 priority, 2:string exceptionText);

	string handleInputHandler(1:string prompt, 2:string defaultValue, 3:list<string> choices)
}