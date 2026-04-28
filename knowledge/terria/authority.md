# Design Constraints & Review Process

## File Modification Constraints

**CRITICAL**: Structure.md contains the authoritative registry design and must NOT be edited without explicit user consent.

- `structure.md` - **READ-ONLY** - User review required before any edits
- `proposed_structure_update.md` - Proposed changes go here, user reviews and approves
- Other files in `knowledge/` - Can be created/edited with design documentation

## Design Principles

### Multi-Registry Architecture
- **Terraform first**: Start with terraform registry implementation as proof of concept
- **Generic naming**: Use `plugins/` instead of `providers/` for consistency across future registry types
- **Protocol compatibility**: Use symlinks to maintain backward compatibility with Terraform Registry Protocol
- **Extensibility**: Structure enables adding kubernetes, docker, and other registry types

### Symlink Strategy for Compatibility
- Actual folder: `registry/registry.terraform.io/plugins/` (generic, extensible naming)
- Symlink: `providers@ -> plugins/` (protocol compatibility)
- Benefit: No code changes needed, all existing `/providers/` endpoints continue to work

### Folder Organization
```
registry.terraform.io/
├── modules/           # Terraform modules
├── plugins/           # Actual implementation (generic naming)
└── providers@ -> plugins/  # Symlink for protocol compatibility
```

## Review & Approval Process

1. **Propose**: Create files documenting proposed changes in `knowledge/` folder
2. **User Review**: Wait for user feedback and explicit approval
3. **Implement**: Only proceed with changes after user approval
4. **Verify**: Test symlinks and verify protocol compatibility

## Key Decisions

- **Symlink over code changes**: Prefer symlinks over code modifications for protocol compatibility (simpler, more maintainable)
- **Structure-first design**: Design folder structure first, then implement code to match
- **Incremental rollout**: Focus on terraform first, design placeholders for future registry types
