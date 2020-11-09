// Copyright 2017-2020, Institute for Artificial Intelligence - University of Bremen

#pragma once

#include "Modules/ModuleManager.h"

class FUProtobufModule : public IModuleInterface
{
public:

	/** IModuleInterface implementation */
	virtual void StartupModule() override;
	virtual void ShutdownModule() override;
};
